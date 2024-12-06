import {Component, OnInit} from '@angular/core';
import {BudgetService} from "../../services/budget.service";
import {Budget} from "../../../core/models/budget.model";
import {ExpenseService} from "../../services/expense.service";
import {BudgetAlertService} from "../../services/budget-alert.service";
import {Expense} from "../../../core/models/expense.model";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {


  budgetLimit!: number;
  currentSpent!: number;
  recentExpenses!: Expense[];

  constructor(private budgetService: BudgetService,
              private expenseService: ExpenseService,
              private budgetAlertService: BudgetAlertService
  ) {
  }

  ngOnInit(): void {
    this.budgetService.getCurrentBudget().subscribe(
      {
        next: (response: Budget) => {
          this.budgetLimit = Number(response.budgetLimit)
          this.budgetAlertService.setBudgetLimit(Number(response.budgetLimit))
        }
      }
    )

    this.expenseService.getCurrentMonthSpent().subscribe({
        next: (response: string) => {
          this.currentSpent = Number(response)
          this.budgetAlertService.setCurrentSpent(Number(response))
        }
      }
    )

    this.expenseService.getMostRecent().subscribe({
      next: (response: Expense[]) => {
        this.recentExpenses = response
      }
    })

    this.budgetAlertService.budgetExceeded$.subscribe();
  }

  get budgetProgress() {
    return ((this.currentSpent / this.budgetLimit) * 100).toFixed(2);
  }



}
