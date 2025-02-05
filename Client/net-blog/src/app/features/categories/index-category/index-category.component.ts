import { Component, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { RouterLink } from '@angular/router';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/category.model';
import { CommonModule } from '@angular/common';
import { defaultIfEmpty, Observable } from 'rxjs';

@Component({
  selector: 'app-index-category',
  imports: [CommonModule ,MatTableModule, MatButtonModule, MatCardModule, RouterLink],
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
