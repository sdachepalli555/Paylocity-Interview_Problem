import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { EmployeeService } from 'src/app/Shared/employee.service';
import { Employee } from 'src/app/Shared/employee.model';



@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {

  employeeForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private employeeService: EmployeeService,
    private router: Router
  ) {}

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.initForm();
    });
  }

  onSubmit() {    
    this.employeeService.saveEmployee(this.employeeForm.value);

    this.onCancel();
  }

  onAddDependent() {
    (<FormArray>this.employeeForm.get('employeeDependents')).push(
      new FormGroup({
        firstName: new FormControl(null, Validators.required),
        lastName: new FormControl(null, Validators.required)
      })
    );
  }

  onDeleteDependent(index: number) {
    (<FormArray>this.employeeForm.get('employeeDependents')).removeAt(index);
  }

  onCancel() {
    this.router.navigate(['../'], { relativeTo: this.route });
  }

  private initForm() {

    this.employeeForm = new FormGroup({
      firstName: new FormControl(null, Validators.required),
      lastName: new FormControl(null, Validators.required),
      employeeDependents: new FormArray([])
    });
    
  }
}