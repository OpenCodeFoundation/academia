import { Component, OnInit } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { ClassInfo } from "../../model/ClassInfo";
import { ClassinfoService } from "../../model/classinfo.service";
import { Router } from "@angular/router";

@Component({
  selector: 'app-classinfo-list',
  templateUrl: './classinfo-list.component.html',
  styleUrls: ['./classinfo-list.component.css']
})
export class ClassinfoListComponent implements OnInit {

  classinfos: Observable<ClassInfo[]>;

  constructor(
    private classinfoService: ClassinfoService,
    private router: Router) { }

  ngOnInit() {
    this.classinfos = this.classinfoService.getClassInfos();
  }

  deleteInstitute(classInfo: ClassInfo) {
    this.classinfoService.deleteClassInfo(classInfo)
      .subscribe(() => {
        this.classinfos = this.classinfoService.getClassInfos();
      });
  }

  editInstitute(classInfo: ClassInfo) {
    this.router.navigate(['/classinfo', classInfo.id]);
  }

}
