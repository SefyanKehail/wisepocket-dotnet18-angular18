import {Injectable} from '@angular/core';
import {BehaviorSubject} from "rxjs";
import {MatSnackBar} from "@angular/material/snack-bar";

@Injectable({
  providedIn: 'root'
})
export class BudgetAlertService {
  private _budgetExceededSubject = new BehaviorSubject<boolean>(false);
  public budgetExceeded$ = this._budgetExceededSubject.asObservable();

  private budgetLimit = 2000;
  private currentSpent = 0;

  constructor(private snackBar: MatSnackBar) {
  }

  setBudgetLimit(value: number) {
    this.budgetLimit = value;
  }

  setCurrentSpent(value: number) {
    this.currentSpent = value;
    this.checkBudget();
  }

  checkBudget(): void {
    if (this.currentSpent > this.budgetLimit) {
      this._budgetExceededSubject.next(true);
      this.showToast('Be careful you exceeded the budget limit for this month!');
    } else {
      this._budgetExceededSubject.next(false);
    }
  }

  private showToast(message: string): void {
    this.snackBar.open(message, 'Close', {
      duration: 5000,
      verticalPosition: 'top',
      horizontalPosition: 'center',
    });
  }
}
