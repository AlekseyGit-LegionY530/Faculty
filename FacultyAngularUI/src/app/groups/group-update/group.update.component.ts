import {Component, OnInit} from "@angular/core";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {GroupService} from "../services/group.service";
import {GroupDto} from "../models/group.dto";
import {SpecializationService} from "../../specializations/services/specialization.service";
import {SpecializationDto} from "../../specializations/models/specialization.dto";

@Component({
  selector: 'app-curator-update',
  templateUrl: './group.update.component.html'
})
export class GroupUpdateComponent implements OnInit {
  public form: FormGroup = new FormGroup({ });
  public specializations: SpecializationDto[] = [];
  public group: GroupDto | undefined;

  constructor(private groupService: GroupService,
              private specializationService: SpecializationService,
              private activatedRoute: ActivatedRoute,
              private router: Router){
  }

  ngOnInit() : void {
    this.specializationService.getSpecializations().subscribe(response => {
      response.forEach(data => this.specializations.push(new SpecializationDto(data.name, data.id)))
      console.log("Specializations", this.specializations);
    })

    let id = 0;
    this.activatedRoute.params.subscribe(params => {
      console.log(params);
      id = params['id'];
    });

    this.form = new FormGroup({
      "name": new FormControl('',
        [ Validators.required, Validators.maxLength(50) ]),
      "specializationId": new FormControl('',
        [ Validators.required ]),
    });

    this.groupService.getGroup(id).subscribe(response => {
      this.group = response;
      this.form.patchValue({
        name: this.group.name
      });
      console.log("Name", this.group.name);
    });
  }

  submit(): void {
    let group: GroupDto = new GroupDto(this.form.value.name, this.form.value.specializationId, this.group?.id);
    this.groupService.updateGroup(group).subscribe(response => {
      console.log(response);
      this.router.navigateByUrl('/curator/index');
    });
  }
}
