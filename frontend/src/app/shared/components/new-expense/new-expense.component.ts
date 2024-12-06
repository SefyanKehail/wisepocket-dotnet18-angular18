import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {Router} from "@angular/router";
import {CategoryService} from "../../services/category.service";
import {CreateExpenseDto} from "../../../core/DTOs/create-expense.dto";
import {ExpenseService} from "../../services/expense.service";
import {Category} from "../../../core/models/category.model";

@Component({
  selector: 'app-new-expense',
  templateUrl: './new-expense.component.html',
  styleUrl: './new-expense.component.scss'
})
export class NewExpenseComponent implements OnInit{
  newExpenseFormGroup!: FormGroup;
  categories!: Category[];

  constructor(private router: Router,
              private categoryService: CategoryService,
              private expenseService: ExpenseService,
  ) {
  }

  ngOnInit(): void {
    this.categoryService.getAll().subscribe({
      next: (response: Category[]) => {
        this.categories = response;
      },
      error: err => console.log(err)
    })

    this.newExpenseFormGroup = new FormGroup({
      name: new FormControl(),
      amount: new FormControl(),
      date: new FormControl(),
      categoryId: new FormControl()
    })
  }

  save(): void {
    if (this.newExpenseFormGroup.valid) {
      const expenseData = this.newExpenseFormGroup.value;
      console.log(expenseData);

      const createExpenseDto: CreateExpenseDto =
        {
          name: expenseData.name,
          amount: expenseData.amount,
          date: expenseData.date,
          categoryId: expenseData.categoryId,
          userId: "1"
        }

      this.expenseService.create(createExpenseDto).subscribe({
        next: (response) => {
          this.router.navigate(['/expense']);
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
