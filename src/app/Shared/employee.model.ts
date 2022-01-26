import { EmployeeDependents } from "./employeedependent.model";

export class Employee {
    employeeId: number;
    firstName: string;
    lastName: string;
    salary: number;
    benefitsCostPerYear: number;
    benefitsCostPerPayCheck: number;
    dependentCount: number;
    dependentNames: string;
    displpayName: string;
    employeeDependents: EmployeeDependents[]

    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }
}