import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from "./shared/components/home/home.component";
import {LayoutComponent} from "./core/components/layout/layout.component";
import {ExpenseComponent} from "./shared/components/expense/expense.component";
import {CategoryComponent} from "./shared/components/category/category.component";
import {NewCategoryComponent} from "./shared/components/new-category/new-category.component";
import {NewExpenseComponent} from "./shared/components/new-expense/new-expense.component";

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      {path: 'home', component: HomeComponent, pathMatch: 'full'},
      {path: 'expense', component: ExpenseComponent},
      {path: 'category', component: CategoryComponent},
      {path: 'newCategory', component: NewCategoryComponent},
      {path: 'newExpense', component: NewExpenseComponent},
      {
        path: '', pathMatch: 'full', redirectTo: '/home'
      },
    ]
  },
  {
    path: '', pathMatch: 'full', redirectTo: '/home'
  },
  {
    path: '**', redirectTo: '/home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
