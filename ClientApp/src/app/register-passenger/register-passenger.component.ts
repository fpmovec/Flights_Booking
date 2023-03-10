import { Component, OnInit } from '@angular/core';
import { PassengerService } from './../api/services/passenger.service';
import { FormBuilder } from '@angular/forms';
import { AuthService } from '../auth/auth.service'; 

@Component({
  selector: 'app-register-passenger',
  templateUrl: './register-passenger.component.html',
  styleUrls: ['./register-passenger.component.css']
})
export class RegisterPassengerComponent implements OnInit {

  constructor(private passengerService: PassengerService,
    private fb: FormBuilder,
    private authService: AuthService) { }

  form = this.fb.group({
    email: [''],
    firstName: [''],
    lastName: [''],
    isFemale: [true]
  });

  ngOnInit(): void {
  }

  register() {
    console.log("Form values: ", this.form.value);
    this.passengerService.registerPassenger({ body: this.form.value })
      .subscribe(() => this.authService.loginUser({ email: this.form.get('email')?.value as string }))
  }
}
