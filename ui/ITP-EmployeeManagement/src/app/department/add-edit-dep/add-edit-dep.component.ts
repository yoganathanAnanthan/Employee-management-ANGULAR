import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css']
})
export class AddEditDepComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() dep:any;
  DepartmentId:any;
  DepartmentName:any;
  ManagerId:any;
  NoOfEmp:any;

  ManagersList:any=[];

  ngOnInit(): void {
    this.loadManagersList();
    
    this.DepartmentId=this.dep.DepartmentId;
    this.DepartmentName=this.dep.DepartmentName;
    this.NoOfEmp=this.dep.NoOfEmp;
    this.ManagerId=this.dep.ManagerId;
    

  }

  loadManagersList(){
    this.service.getAllManagerId().subscribe((data:any)=>{
      this.ManagersList=data;

    
    });
  }

  addDepartment(){
    var val={DepartmentId:this.DepartmentId,
              DepartmentName:this.DepartmentName,
              NoOfEmp:this.NoOfEmp,
              ManagerId:this.ManagerId
            }
    this.service.addDepartment(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateDepartment(){
    var val={DepartmentId:this.DepartmentId,
            DepartmentName:this.DepartmentName,
            ManagerId:this.ManagerId,
            NoOfEmp:this.NoOfEmp
          }
    this.service.updateDepartment(val).subscribe(res=>{
    alert(res.toString());
    });
  }

}
