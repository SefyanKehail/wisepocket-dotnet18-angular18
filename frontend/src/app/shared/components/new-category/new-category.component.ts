import {Component, OnInit} from '@angular/core';
import {FormControl, FormControlName, FormGroup} from "@angular/forms";
import {Router} from "@angular/router";
import {CategoryService} from "../../services/category.service";
import {CreateCategoryDto} from "../../../core/DTOs/create-category.dto";

@Component({
  selector: 'app-new-category',
  templateUrl: './new-category.component.html',
  styleUrl: './new-category.component.scss'
})
export class NewCategoryComponent implements OnInit {

  newCategoryFormGroup!: FormGroup;

  constructor(private router: Router, private categoryService: CategoryService) {
  }

  ngOnInit(): void {
    this.newCategoryFormGroup = new FormGroup({
      name: new FormControl()
    })
  }

  save(): void {
    if (this.newCategoryFormGroup.valid) {
      const categoryData = this.newCategoryFormGroup.value;
      console.log(categoryData);

      const createCategoryDto: CreateCategoryDto =
        {
          name: categoryData.name,
          userId: "1"
        }

      this.categoryService.create(createCategoryDto).subscribe({
        next: (response) => {
          this.router.navigate(['/category']);
        },
        error: (err) => {
          console.error(err);
        }
      });
    } else {
      console.log('form is invalid');
    }
  }
}

