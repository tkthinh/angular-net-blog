import { Routes } from '@angular/router';
import { IndexCategoryComponent } from './features/categories/index-category/index-category.component';
import { AddCategoryComponent } from './features/categories/add-category/add-category.component';
import { EditCategoryComponent } from './features/categories/edit-category/edit-category.component';
import { IndexBlogComponent } from './features/blogs/index-blog/index-blog.component';
import { AddBlogComponent } from './features/blogs/add-blog/add-blog.component';
import { EditBlogComponent } from './features/blogs/edit-blog/edit-blog.component';

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
  },
  {
    path: 'admin/blogs',
    component: IndexBlogComponent
  },
  {
    path: 'admin/blogs/add',
    component: AddBlogComponent
  },
  {
    path: 'admin/blogs/:id',
    component: EditBlogComponent
  }
];
