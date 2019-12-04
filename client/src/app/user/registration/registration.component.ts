import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(public service: UserService) {}
    
  ngOnInit() {
     this.service.formModel.reset();
  }

  onSubmit(){
      this.service.register().subscribe(
         (res: any) => {
          console.log(res);
          if (res.Succeeded){
            this.service.formModel.reset();
            alert("Registration successfully completed! ");
          }else {
            res.Errors.forEach((element: { Code: any; }) => {
              switch (element.Code) {
                case 'Duplicate UserName':
                alert(element.Code);
                console.log(element.Code);
                break;
              default:
                 break;
              }
           });
         }
       },
       err => {
       console.log(err);
    }
  )
}
}

