import { Component } from '@angular/core';
import { MatDialogRef} from '@angular/material/dialog';
import { GroupsComponent } from '../groups/groups.component';

@Component({
  selector: 'app-group-dialog',
  templateUrl: './group-dialog.component.html',
  styleUrls: ['./group-dialog.component.scss']
})
export class GroupDialogComponent {

  groupName : string

  constructor(
    public dialogRef: MatDialogRef<GroupsComponent>
  )
  {}
}
