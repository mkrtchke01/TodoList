import { Component } from '@angular/core';
import { MatDialogRef} from '@angular/material/dialog';
import { GroupsComponent } from '../groups/groups.component';

@Component({
  selector: 'app-todo-dialog',
  templateUrl: './todo-dialog.component.html',
  styleUrls: ['./todo-dialog.component.scss']
})
export class TodoDialogComponent {
  todoName : string

  constructor(
    public dialogRef: MatDialogRef<GroupsComponent>
  )
  {}
}
