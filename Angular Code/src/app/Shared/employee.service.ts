import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { from, Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { Employee } from './employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  displayEmployee = new Subject<Employee>();
  constructor(private http: HttpClient) { }
  private getAllEmployeesURL: string = "https://localhost:44310/api/Employee/GetEmployees";
  private saveEmployeeURL: string = "https://localhost:44310/api/Employee/SaveEmployee";

  getAllEmployees() {
    return this.http.get<Employee[]>(this.getAllEmployeesURL);
  }

  saveEmployee(employee: Employee) {
    debugger;
    this.http.post(this.saveEmployeeURL, employee).subscribe(response => {
      console.log(response);
    });
  }
}