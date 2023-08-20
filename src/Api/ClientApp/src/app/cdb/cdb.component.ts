import { Component } from '@angular/core';
import { Form, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CdbService } from './services/cdb.service';
import { Cdb } from './models/cdb.model';

@Component({
  selector: 'app-calculo-cdb',
  templateUrl: './cdb.component.html',
  styleUrls: ['./cdb.component.css']
})
export class CdbComponent {
 cdbForm: FormGroup;
 grossResult: number = 0;
 liquidResult: number = 0;

  constructor(private fb: FormBuilder, private service: CdbService) {
    this.cdbForm = this.fb.group({
      cash: [null, Validators.required],
      deadline: [null, this.validateDeadlineMoreThenOne]
    });
  }

  send() {
    if (!this.cdbForm.invalid) {
      const cdb: Cdb = new Cdb(
        this.cdbForm.value.cash,
        this.cdbForm.value.deadline
      );
      this.service.calculate(cdb).subscribe(
        (data) => {
          this.grossResult = data.grossResult
          this.liquidResult = data.liquidResult;
        },
        (error) => {
          console.log(cdb);
        }
      );    
      return;
    }
  }

  validateDeadlineMoreThenOne(input: FormControl){
    return ( input.value > 1 ? null : { invalid: true });
  }
}
