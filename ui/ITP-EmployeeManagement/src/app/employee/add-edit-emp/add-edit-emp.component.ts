import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import {FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-add-edit-emp',
  templateUrl: './add-edit-emp.component.html',
  styleUrls: ['./add-edit-emp.component.css']
})
export class AddEditEmpComponent implements OnInit {
  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  constructor(private service:SharedService) { }

  @Input() emp:any;
  EmployeeId:any;
  EmployeeName:any;
  DepId:any;
  DateOfJoining:any;
  PhotoFileName:any;
  PhotoFilePath:any;
  PhoneNumber:any;
  EmailAddress:any;
  Position:any;
  Salary:any;

  DepartmentsList:any=[];


  ngOnInit(): void {
      
    this.loadDepartmentList();
  }

  loadDepartmentList(){
    this.service.getAllDepartmentId().subscribe((data:any)=>{
      this.DepartmentsList=data;

      this.EmployeeId=this.emp.EmployeeId;
      this.EmployeeName=this.emp.EmployeeName;
      this.DepId=this.emp.DepId;
      this.DateOfJoining=this.emp.DateOfJoining;
      this.PhotoFileName=this.emp.PhotoFileName;
      this.PhoneNumber=this.emp.PhoneNumber;
      this.EmailAddress=this.emp.EmailAddress;
      this.Position=this.emp.Position;
      this.Salary=this.emp.Salary;
      this.PhotoFilePath=this.service.PhotoUrl+this.PhotoFileName;
    });
  }

  addEmployee(){
    var val={EmployeeId:this.EmployeeId,
              EmployeeName:this.EmployeeName,
              DepId:this.DepId,
              DateOfJoining:this.DateOfJoining,
              PhotoFileName:this.PhotoFileName,
              PhoneNumber:this.PhoneNumber,
              EmailAddress:this.EmailAddress,
              Position:this.Position,
              Salary:this.Salary
            };

    this.service.addEmployee(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateEmployee(){
    var val={EmployeeId:this.EmployeeId,
      EmployeeName:this.EmployeeName,
      DepId:this.DepId,
      DateOfJoining:this.DateOfJoining,
      PhotoFileName:this.PhotoFileName,
      PhoneNumber:this.PhoneNumber,
      EmailAddress:this.EmailAddress,
      Position:this.Position,
      Salary:this.Salary
    };

    this.service.updateEmployee(val).subscribe(res=>{
    alert(res.toString());
    });
  }

  uploadPhoto(event:any){
    var file=event.target.files[0];
    const formData:FormData=new FormData();
    formData.append('uploadedFile',file,file.name);

    this.service.Uploadphoto(formData).subscribe((data:any)=>{
      this.PhotoFileName=data.toString();
      this.PhotoFilePath=this.service.PhotoUrl+this.PhotoFileName;
    })
  }

}
