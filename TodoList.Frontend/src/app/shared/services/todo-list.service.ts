import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Group } from '../models/group';
import { TodoList } from '../models/todoList';

@Injectable({
  providedIn: 'root'
})
export class TodoListService {

  constructor(private http : HttpClient) { }

  readonly apiUrl = 'https://localhost:7231/odata/'

  getTodoList(groupId : number){
    return this.http.get<any>(this.apiUrl + 'todo(' + groupId + ')');
  }

  getGroups(){
    return this.http.get<any>(this.apiUrl + 'group');
  }

  createGroup(group : Group){
    return this.http.post(this.apiUrl + 'group', group);
  }

  updateTodo(todoId: number, todo:TodoList){
    return this.http.put(this.apiUrl + 'todo(' + todoId + ')', todo)
  }

  createTodo(todo : TodoList){
    return this.http.post(this.apiUrl + 'todo', todo);
  }

  deleteGroup(groupId : number){
    return this.http.delete(this.apiUrl + 'group(' + groupId + ')');
  }

  deleteTodo(todoId: number){
    return this.http.delete(this.apiUrl + 'todo(' + todoId + ')');
  }

}
