import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-identity-register',
  templateUrl: './identity-register.component.html',
  styleUrls: ['./identity-register.component.css']
})
export class IdentityRegisterComponent implements OnInit {
  // FormGroup is a class to manage related form controls in a form 
  registerationForm: FormGroup;
  constructor() { }

  ngOnInit() {
    this.registerationForm = new FormGroup(
      {
        // apply field validators
        // comtrol level validators
        userName: new FormControl(null, Validators.required),
        email: new FormControl(null, [Validators.required, Validators.email]),
        password: new FormControl(null, [Validators.required, Validators.minLength(8)]),
        confirmPassword: new FormControl(null, [Validators.required]),
        mobile: new FormControl(null, [Validators.required, Validators.maxLength(10)]),
        // a form level validator 
      }, this.confirmPassValidator);

  }
  // customer validator to check if confirmPassword matches with password
  confirmPassValidator(fg: FormGroup): Validators {

    return fg.get('password').value === fg.get('confirmPassword').value ? null : { passwordsNotMatched: true };
  }

  // use get method to retrieve user name entered in the form
  // then pass it to the template to determine if the error message should be displayed
  get userName() {

    return this.registerationForm.get('userName') as FormControl;
  }

  get email() {

    return this.registerationForm.get('email') as FormControl;
  }

  get password() {

    return this.registerationForm.get('password') as FormControl;
  }

  get confirmPassword() {

    return this.registerationForm.get('confirmPassword') as FormControl;
  }

  get mobile() {

    return this.registerationForm.get('mobile') as FormControl;
  }

  onSubmit() {
    console.log(this.registerationForm);
  }

}
