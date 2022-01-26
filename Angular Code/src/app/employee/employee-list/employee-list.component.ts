import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from '../../Shared/employee.model';
import { EmployeeService } from '../../Shared/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  employees: Employee[] = [];

  constructor(private employeeService: EmployeeService, private route: ActivatedRoute,
    private router: Router) { }  

  ngOnInit() {
    this.employeeService.getAllEmployees().subscribe
      (
        (response) => {
          this.employees = response;
        },
        (error) => console.log(error)
      )
  }
  displayedColumns: string[] = 
    ['displpayName', 'dependentCount', 'dependentNames', 'salary', 'benefitsCostPerYear','benefitsCostPerPayCheck'];
}
