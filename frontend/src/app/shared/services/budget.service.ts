import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {Budget} from "../../core/models/budget.model";

@Injectable({
  providedIn: 'root'
})
export class BudgetService {

  constructor(private httpClient : HttpClient) { }

  getCurrentBudget(){
    const currentDate = new Date();
    const currentDateISO = currentDate.toISOString()
    return this.httpClient.get<Budget>(environment.host + `/budget?monthYear=${currentDateISO}`);
  }
}
