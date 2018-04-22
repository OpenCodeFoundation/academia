import { Component, OnInit } from '@angular/core';
import { InstituteService } from '../../model/institute.service';
import { Observable } from 'rxjs/Observable';
import { Institute } from '../../model/institute';

@Component({
  selector: 'app-institute-list',
  templateUrl: './institute-list.component.html',
  styleUrls: ['./institute-list.component.css']
})
export class InstituteListComponent implements OnInit {

  institutes: Observable<Institute[]>;

  constructor(private instituteService: InstituteService) { }

  ngOnInit() {
    this.institutes = this.instituteService.getInstitutes();
  }

  deleteInstitute(institute: Institute) {
    this.instituteService.deleteInstitute(institute)
      .subscribe(() => {
        this.institutes = this.instituteService.getInstitutes();
      });
  }

}
