import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/category.model';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Observable } from 'rxjs';

import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatError, MatLabel } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { UpdateCategoryRequest } from '../models/update-category-request.model';

@Component({
  selector: 'app-edit-category',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatLabel,
    MatError,
  ],
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css'],
})
export class EditCategoryComponent implements OnInit {
  categoryForm: FormGroup;
  categoryId: string | null = null;
  category?: Category;

  constructor(
    private categoryService: CategoryService,
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.categoryForm = this.fb.group({
      name: ['', [Validators.required]],
      slug: [
        '',
        [Validators.required, Validators.pattern('^[a-z0-9]+(?:-[a-z0-9]+)*$')],
      ],
    });
  }

  ngOnInit(): void {
    // Get the category ID from the URL
    this.categoryId = this.route.snapshot.paramMap.get('id');

    if (this.categoryId) {
      // Fetch the category details
      this.categoryService.getCategoryById(this.categoryId).subscribe({
        next: (category) => {
          this.category = category;
          this.categoryForm.patchValue(category); // Populate the form with current category data
        },
        error: (err) => {
          console.error('Error fetching category details', err);
        },
      });
    }
  }

  // Handle form submission (update category)
  onSubmit(): void {
    if (this.categoryForm.valid) {
      const updateCategoryRequest: UpdateCategoryRequest = {
        name: this.categoryForm.value.name,
        slug: this.categoryForm.value.slug,
      };

      if (this.categoryId) {
        this.categoryService
          .updateCategory(this.categoryId, updateCategoryRequest)
          .subscribe({
            next: () => {
              this.router.navigate(['/admin/categories']); // Redirect to categories list after update
            },
            error: (err) => {
              console.error('Error updating category', err);
            },
          });
      }
    }
  }

  // Handle category deletion
  deleteCategory(): void {
    if (this.categoryId) {
      if (confirm('Are you sure you want to delete this category?')) {
        this.categoryService.deleteCategory(this.categoryId).subscribe({
          next: () => {
            this.router.navigate(['/categories']); // Redirect to categories list after delete
          },
          error: (err) => {
            console.error('Error deleting category', err);
          },
        });
      }
      else return;
    }
  }
}
