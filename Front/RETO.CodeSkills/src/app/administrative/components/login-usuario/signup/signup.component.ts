import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginUsuarioService } from 'src/app/administrative/services/login-usuario.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit{

  type: string = "password";
  isText: boolean = false;
  eyeIcon : string = "fa-eye-slash";
  signUpForm!: FormGroup;

  constructor(private fb : FormBuilder, private auth : LoginUsuarioService){}
  ngOnInit(): void {
    this.signUpForm = this.fb.group({
      nombreLoginUsuario: ['', Validators.required],
      contraseñaLoginUsuario: ['', Validators.required]
    })
  }
  hideShowPass(){
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "password";
  }

  onSignUp(){
    if(this.signUpForm.valid){
      this.auth.signUp(this.signUpForm.value).subscribe({
        next:(respuesta=>{
          alert(respuesta)
        }),
        error:(err=>{
          alert(err.error.message)
        })
      })
      console.log(this.signUpForm.value)
    }else{
      ValidateForm.validateAllFormFileds(this.signUpForm)
    }
  }

}
