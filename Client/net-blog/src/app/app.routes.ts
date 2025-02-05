import { Routes } from '@angular/router';
import { IndexCategoryComponent } from './features/categories/index-category/index-category.component';
import { AddCategoryComponent } from './features/categories/add-category/add-category.component';
import { EditCategoryComponent } from './features/categories/edit-category/edit-category.component';

export const routes: Routes = [
  {
    path: 'admin/categories',
    component: IndexCategoryComponent
  },
  {
    path: 'admin/categories/add',
    component: AddCategoryComponent
  },
  {
    path: 'admin/categories/:id',
    component: EditCategoryComponent
  }
];
