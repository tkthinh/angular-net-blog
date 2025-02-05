import { Component, OnDestroy } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { FormsModule } from '@angular/forms';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { CategoryService } from '../services/category.service';
import { Subscription } from 'rxjs';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-add-category',
  imports: [
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    FormsModule,
    RouterLink,
  ],
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css',
})
export class AddCategoryComponent implements OnDestroy {
  model: AddCategoryRequest;
  private addCategorySubscription?: Subscription;

  constructor(
    private categoryService: CategoryService,
    private router: Router
  ) {
    this.model = { name: '', slug: '' };
  }

  ngOnDestroy(): void {
    this.addCategorySubscription?.unsubscribe();
  }

  onFormSubmit() {
    this.addCategorySubscription = this.categoryService
      .addCategory(this.model)
      .subscribe({
        next: (res) => {
          this.router.navigateByUrl('/admin/categories');
        },
        error: (err) => {
          console.error('Error adding category', err);
        },
      });
  }
}
