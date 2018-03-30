import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'addinstitute',
    templateUrl: './addinstitute.component.html'
})
export class AddInstituteComponent {
    public institute: Institute = new Institute();
    public success: boolean = false;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public addInstitute() {
        this.http.post(this.baseUrl + 'api/Institute', this.institute).subscribe(result => {
            this.institute = new Institute();
            this.success = true;
        }, error => console.log(error));
    }

    public hideAlert() {
        this.success = false;
    }
}

class Institute {
    name: string;
    address: string;
    email: string;
}