import { Component } from '@angular/core';
import { EmployeeService } from '../Shared/employee.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent {
  constructor(private employeeService: EmployeeService) {}  

  onFetchData() {
    this.employeeService.getAllEmployees().subscribe();
  }
}
