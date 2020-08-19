import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Local } from 'protractor/built/driverProviders';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-identity-register',
  templateUrl: './identity-register.component.html',
  styleUrls: ['./identity-register.component.css']
})
export class IdentityRegisterComponent implements OnInit {
  // FormGroup is a class to manage related form controls in a form 
  registrationForm: FormGroup;
  // initialze variable account as a javascript object with type any for storing form inputs
  account: UserAccount;
  formSubmitted: boolean;
  // FormBuilder is a helper class provided by Angular that makes it easier to build reactive forms
  // inject user service where methods related to users are defind (eg, addAccount())
  constructor(private formBuilder: FormBuilder, private userService: UserService ) { }

  ngOnInit() {

    this.createRegistrationForm();

  }

  // apply field validators
  createRegistrationForm() {
    this.registrationForm = this.formBuilder.group({
      // control level validators
      userName: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required, Validators.minLength(8)]],
      confirmPassword: [null, Validators.required],
      mobile: [null, [Validators.required, Validators.maxLength(10)]],
      // a form level validator 
    }, { validators: this.confirmPassValidator})
  }
  // customer validator to check if confirmPassword matches with password
  confirmPassValidator(fg: FormGroup): Validators {

    return fg.get('password').value === fg.get('confirmPassword').value ? null : { passwordsNotMatched: true };
  }


  

  // use get method to retrieve user name entered in the form
  get userName() {

    return this.registrationForm.get('userName') as FormControl;
  }

  get email() {

    return this.registrationForm.get('email') as FormControl;
  }

  get password() {

    return this.registrationForm.get('password') as FormControl;
  }

  get confirmPassword() {

    return this.registrationForm.get('confirmPassword') as FormControl;
  }

  get mobile() {

    return this.registrationForm.get('mobile') as FormControl;
  }

  onSubmit() {
    console.log(this.registrationForm.value);
    this.formSubmitted = true;
    // if the form is valid, then submit
    if (this.registrationForm.valid) {

      
      this.userService.addAccount(this.accountData());
      // reset the form when user clicks the submit button
      this.registrationForm.reset();
      this.formSubmitted = false;
    }
    
  }


  accountData(): UserAccount {
    return this.account = {
      // the values of each property is from the get methods defined above
      userName: this.userName.value,
      email: this.email.value,
      password: this.password.value,
      mobile: this.mobile.value

    }
    
  }
  
}
