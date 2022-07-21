import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_service/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
    @Output() cancelRegister = new EventEmitter();
    model: any={};
    registerForm : FormGroup;

  constructor(private accountService: AccountService, private toastr: ToastrService,
    private fb: FormBuilder, private router: Router) { }
    validationErrors: string[]=[];

  ngOnInit(): void {
    this.intitializeForm();
  }

  intitializeForm(){
    this.registerForm = new FormGroup({
        username: new FormControl('',[Validators.required, Validators.minLength(4), Validators.maxLength(8)]),
        password: new FormControl('',[Validators.required, Validators.minLength(4), Validators.maxLength(8)]),
        confirmpassword: new FormControl('',[Validators.required, this.matchValues('password')]),
        region: new FormControl('', [Validators.required, Validators.minLength(1)]),
        nickname: new FormControl('', [Validators.required, Validators.minLength(1)]),
        gender: new FormControl('', [Validators.required]),
        preferstyle: new FormControl('', [Validators.required]),
        role: new FormControl('', [Validators.required]),

    })
  }
  matchValues(matchTo: string): ValidatorFn{
    return (control: AbstractControl) => {
        return control?.value === control?.parent?.controls[matchTo].value? null:{isMatching: true}
    }
  }

  register() {
    this.accountService.register(this.registerForm.value).subscribe(response => {
        this.router.navigateByUrl('/puppy-list');
    },error => {
        this.validationErrors = error;
        this.toastr.error(error.error)
    })
}
}
