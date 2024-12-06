import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {Expense} from "../../core/models/expense.model";
import {CreateExpenseDto} from "../../core/DTOs/create-expense.dto";

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {

  constructor(private httpClient: HttpClient) { }

  getAll(){
    return this.httpClient.get<Expense[]>(environment.host + '/expense')
  }

  delete(expenseId: string) {
    return this.httpClient.delete(environment.host + '/expense' + `/${expenseId}`)
  }
  create(createExpenseDto: CreateExpenseDto){
    return this.httpClient.post(environment.host + '/expense', createExpenseDto)
  }

  getCurrentMonthSpent(){
    return this.httpClient.get<string>(environment.host + '/expense' + '/currentMonthSpent')
  }

  getMostRecent(){
    return this.httpClient.get<Expense[]>(environment.host + '/expense' + '/getMostRecent')
  }
}
