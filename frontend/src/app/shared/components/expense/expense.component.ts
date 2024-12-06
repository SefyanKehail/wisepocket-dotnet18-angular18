import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {ExpenseService} from "../../services/expense.service";
import {Expense} from "../../../core/models/expense.model";


@Component({
  selector: 'app-expense',
  templateUrl: './expense.component.html',
  styleUrl: './expense.component.scss'
})
export class ExpenseComponent implements OnInit{

  public expenses: any;
  public dataSource: any;
  public displayedColumns: string[] = ["id", "name", "amount", "categoryName","date", "actions"];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private expenseService: ExpenseService) {
  }
  ngOnInit(): void {
    this.expenseService.getAll().subscribe({
      next: (response: Expense[]) => {
        this.expenses = response;
        this.dataSource = new MatTableDataSource(this.expenses);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }
    })
  }

  getAllExpenses(){
    this.expenseService.getAll().subscribe({
      next: (response: Expense[]) => {
        this.expenses = response;
        this.dataSource = new MatTableDataSource(this.expenses);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }
    })
  }

  delete(expenseId: string){
    this.expenseService.delete(expenseId).subscribe(
      {
        next: value => {
          this.getAllExpenses()
        }
      }
    )
  }
}
