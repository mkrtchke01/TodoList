import { Component } from '@angular/core';
import { Group } from 'src/app/shared/models/group';
import { TodoList } from 'src/app/shared/models/todoList';
import { TodoListService } from 'src/app/shared/services/todo-list.service';
import {MatDialog} from '@angular/material/dialog';
import { TodoDialogComponent } from '../todo-dialog/todo-dialog.component';
import { GroupDialogComponent } from '../group-dialog/group-dialog.component';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.scss']
})
export class GroupsComponent {

  groups : Group[]
  todoList : TodoList[]
  currentOpenedItemId: number
  expandAdding:boolean
  groupName : string
  todoName: string

  
  constructor(private todoListService: TodoListService, private dialog: MatDialog) { }

  ngOnInit() { 
    this.getGroups()
  }

  getGroups(){
    this.todoListService.getGroups().subscribe(data => {
      this.groups = data.value
    });
  }

  getTodoList(groupId : number){
    this.todoListService.getTodoList(groupId).subscribe(data => {
      this.todoList = data.value
    });
  }

  createGroup(){
    var group = new Group
    group.GroupName = this.groupName
    this.todoListService.createGroup(group).subscribe(()=>{
      this.expandAdding = false
      this.groupName=''
      this.getGroups();
    });
  }

  createTodo(groupId: number){
    var todo = new TodoList
    todo.IsCompleted = false
    todo.GroupId = groupId
    todo.TodoName = this.todoName
    this.todoListService.createTodo(todo).subscribe(()=>{
      this.todoName=''
      this.getTodoList(groupId);
    });
  }

  deleteGroup(groupId : number){
    this.todoListService.deleteGroup(groupId).subscribe(()=>{
      this.getGroups();
    });
  }
  deleteTodo(todoId: number, groupId: number){
    this.todoListService.deleteTodo(todoId).subscribe(()=>{
      this.getTodoList(groupId);
    });
  }

  public handleOpened(group : Group): void { 
    this.currentOpenedItemId = group.GroupId;
  }

  changeStatus(todoId: number, todo: TodoList, groupId: number){
    this.todoListService.updateTodo(todoId, todo).subscribe(()=>{
      this.getTodoList(groupId);
    })
  }

  openTodoDialog(groupId: number): void {
    const dialogRef = this.dialog.open(TodoDialogComponent);
    dialogRef.afterClosed().subscribe(result => {
      if(result!=null){
        this.todoName = result;
        this.createTodo(groupId)}
    });
  }

  openGroupDialog(): void {
    const dialogRef = this.dialog.open(GroupDialogComponent);
    dialogRef.afterClosed().subscribe(result => {
      if( result != null ){
        this.groupName = result;
        this.createGroup()}
    });
  }

}
