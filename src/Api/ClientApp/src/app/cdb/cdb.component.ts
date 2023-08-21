import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CdbService } from './services/cdb.service';
import { Cdb } from './models/cdb.model';

@Component({
  selector: 'app-calculo-cdb',
  templateUrl: './cdb.component.html',
  styleUrls: ['./cdb.component.css']
})
export class CdbComponent {
  cdbForm: FormGroup = this.fb.group({
    cash: [null, Validators.compose([Validators.required, Validators.min(1)])],
    deadline: [null, this.validateDeadlineMoreThenOne]
  });
 grossResult: number = 0;
 liquidResult: number = 0;

  constructor(private fb: FormBuilder, private service: CdbService) { }

  send() {
    if (!this.cdbForm.invalid) {
      const cdb: Cdb = new Cdb(
        this.cdbForm.value.cash.replace(/\./g, '').replace(/,/g,'.'),
        this.cdbForm.value.deadline
      );
      this.service.calculate(cdb).subscribe(
        {
          next: (data) => {
            this.grossResult = data.grossResult
            this.liquidResult = data.liquidResult;
          },
          error: () => {

          }
        });    
    }
  }

  validateDeadlineMoreThenOne(input: FormControl){
    return ( input.value > 1 ? null : { invalid: true });
  }

  validateCashFormat() {
    return this.cdbForm.value.cash.match(/^(\d{1,3}(\.\d{3})*(,\d+)?|\d*,\d+|\d+)$/g);
  }

  validateDeadlineFormat() {
    return this.cdbForm.value.deadline.toString().match(/^\d*$/g);
  }
}
