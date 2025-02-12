import { Category } from "../../categories/models/category.model";

export interface Blog {
  id: string,
  title: string;
  shortDescription: string;
  content: string;
  thumbnailUrl: string;
  slug: string;
  author: string;
  publishedDate: Date;
  isVisible: boolean;
  categories: Category[];
}