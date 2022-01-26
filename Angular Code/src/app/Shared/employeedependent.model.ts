export class EmployeeDependents {
    dependentId: number;
    employeeId: number;
    firstName: string;
    lastName: string;

    constructor( firstName, lastName,) {
        this.firstName = firstName;
        this.lastName = lastName;
    }
}