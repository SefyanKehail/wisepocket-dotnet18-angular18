import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {Category} from "../../core/models/category.model";
import {CreateCategoryDto} from "../../core/DTOs/create-category.dto";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpClient : HttpClient) { }

  getAll(){
    return this.httpClient.get<Category[]>(environment.host + '/category');
  }

  delete(categoryId: string) {
    return this.httpClient.delete(environment.host + '/category' + `/${categoryId}`)
  }

  create(createCategoryDto: CreateCategoryDto){
    return this.httpClient.post(environment.host + '/category', createCategoryDto)
  }
}
