import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { Category } from '../models/category.model';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-index-category',
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatCardModule,
    RouterLink,
  ],
  templateUrl: './index-category.component.html',
  styleUrl: './index-category.component.css',
})
export class IndexCategoryComponent implements OnInit {
  categories$?: Observable<Category[]>;
  displayedColumns: string[] = ['id', 'name', 'slug', 'actions'];

  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCategories();
  }
}
