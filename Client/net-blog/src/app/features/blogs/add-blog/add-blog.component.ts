import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';

import { CommonModule } from '@angular/common';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MarkdownModule } from 'ngx-markdown';
import { Observable } from 'rxjs';
import { Category } from '../../categories/models/category.model';
import { CategoryService } from '../../categories/services/category.service';
import { AddBlogModel } from '../models/add-blog-request-model';
import { BlogService } from '../services/blog.service';

@Component({
  selector: 'app-add-blog',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MarkdownModule,
    MatLabel,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatOptionModule,
    MatDatepickerModule,
    MatCheckboxModule,
    MatButtonModule,
  ],
  templateUrl: './add-blog.component.html',
  styleUrl: './add-blog.component.css',
})
export class AddBlogComponent implements OnInit {
  blogForm: FormGroup;
  categories$?: Observable<Category[]>;
  markdownPreview: string = '';
  thumbnailUrl: string = '';

  constructor(
    private fb: FormBuilder,
    private blogService: BlogService,
    private categoryService: CategoryService,
    public router: Router,
  ) {
    this.blogForm = this.fb.group({
      title: ['', [Validators.required, Validators.minLength(3)]],
      slug: [
        '',
        [Validators.required, Validators.pattern('^[a-z0-9]+(?:-[a-z0-9]+)*$')],
      ],
      shortDescription: ['', [Validators.required, Validators.minLength(10)]],
      content: ['', [Validators.required, Validators.minLength(20)]],
      thumbnailUrl: ['', [Validators.required]],
      publishDate: ['', [Validators.required]],
      category: ['', [Validators.required]],
      author: ['', [Validators.required]],
      isPublished: [false], // Checkbox default to false
    });
  }

  updatePreview(): void {
    this.markdownPreview = this.blogForm.get('content')?.value || '';
  }

  updateThumbnail(): void {
    this.thumbnailUrl = this.blogForm.get('thumbnailUrl')?.value || '';
  }

  onImageError(event: Event): void {
    (event.target as HTMLImageElement).src =
      'https://images.pexels.com/photos/28216688/pexels-photo-28216688/free-photo-of-autumn-camping.png?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1';
  }

  onSubmit(): void {
    if (this.blogForm.valid) {
      const blogData: AddBlogModel = this.blogForm.value;

      this.blogService.createBlog(blogData).subscribe({
        next: (response) => {
          console.log('Blog created:', response);
          this.router.navigate(['/admin/blogs']);
        },
        error: (err) => {
          console.error('Error creating blog:', err);
        },
      });
    }
  }

  navigateToBlogs(): void {
    this.router.navigate(['/admin/blogs']);
  }

  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCategories();
  }
}
