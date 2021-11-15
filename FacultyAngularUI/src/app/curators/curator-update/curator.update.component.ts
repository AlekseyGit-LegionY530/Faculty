import {Component, OnInit} from "@angular/core";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {CuratorDto} from "../models/curator.dto";
import {CuratorsService} from "../services/curator.service";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-curator-update',
  templateUrl: './curator.update.component.html'
})
export class CuratorUpdateComponent implements OnInit {
  public form: FormGroup = new FormGroup({ });
  private curator: CuratorDto | undefined;

  constructor(private curatorsService: CuratorsService,
              private activatedRoute: ActivatedRoute,
              private router: Router){
  }

  ngOnInit() : void {
    let id = 0;
    this.activatedRoute.params.subscribe(params => {
      console.log(params);
      id = params['id'];
    });

    this.form = new FormGroup({
      surname: new FormControl('',
        [ Validators.required, Validators.maxLength(50) ]),
      name: new FormControl('',
        [ Validators.required, Validators.maxLength(50) ]),
      doublename: new FormControl('',
        [ Validators.required, Validators.maxLength(50) ]),
      phone: new FormControl('',
        [ Validators.required ])
    });

    this.curatorsService.getCurator(id).subscribe(response => {
      this.curator = response;
      this.form.patchValue({
        surname: this.curator.surname,
        name: this.curator.name,
        doublename: this.curator.doublename,
        phone: this.curator.phone
      });
    });
  }

  submit() : void {
    let curator: CuratorDto = new CuratorDto(this.form.value.surname,
      this.form.value.name, this.form.value.doublename, this.form.value.phone, this.curator?.id);
    this.curatorsService.updateCurator(curator).subscribe(response => {
      console.log(response);
      this.router.navigateByUrl('/curator/index');
    });
  }
}
