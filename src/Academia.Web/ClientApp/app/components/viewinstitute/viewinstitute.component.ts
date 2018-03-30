import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'viewinstitute',
    templateUrl: './viewinstitute.component.html'
})
export class ViewInstituteComponent {
    public institutes: Institute[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Institute').subscribe(result => {
            this.institutes = result.json() as Institute[];
        }, error => console.error(error));
    }
}

export interface Institute {
    name: string;
    address: string;
    email: string;
}
