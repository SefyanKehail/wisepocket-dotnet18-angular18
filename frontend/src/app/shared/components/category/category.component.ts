import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {MatTableDataSource} from "@angular/material/table";
import {CategoryService} from "../../services/category.service";
import {Category} from "../../../core/models/category.model";
import {Router} from "@angular/router";

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrl: './category.component.scss'
})
export class CategoryComponent implements OnInit {
  public categories: any;
  public dataSource: any;
  public displayedColumns: string[] = ["id", "name", "actions"];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private categoryService: CategoryService, private router: Router) {
  }

  ngOnInit(): void {
    this.getAllCategories()
  }

  getAllCategories(){
    this.categoryService.getAll().subscribe(
      {
        next: (response: Category[]) => {
          this.categories = response;
          this.dataSource = new MatTableDataSource(this.categories);
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
        },
        error: err => {
          console.log(err)
        }
      }
    )
  }

  deleteCategory(categoryId: string) {
    this.categoryService.delete(categoryId).subscribe(
      {
        next: value => {
          this.getAllCategories()
        }
      }
    );
  }

}
