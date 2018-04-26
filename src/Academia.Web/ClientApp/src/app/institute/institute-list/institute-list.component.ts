import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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

  constructor(
    private instituteService: InstituteService,
    private router: Router) { }

  ngOnInit() {
    this.institutes = this.instituteService.getInstitutes();
  }

  deleteInstitute(institute: Institute) {
    this.instituteService.deleteInstitute(institute)
      .subscribe(() => {
        this.institutes = this.instituteService.getInstitutes();
      });
  }

  editInstitute(institute: Institute) {
    this.router.navigate(['/institute', institute.id]);
  }
  

}
