import { Injectable } from '@angular/core';

@Injectable()
export class FechasService {
    
    GetDateDMY(stringDate: string): string {
        const [year, month, day] = stringDate.substring(0,10).split("-")
        return day +"-"+ month +"-"+ year;
    }
    
    GetDateYMD(stringDate: string): string {
        const [year, month, day] = stringDate.substring(0,10).split("-")
        return year +"-"+ month +"-"+ day;
    }

    GetCurrentDate() {
        let day: string = new Date().getDate().toString();
        let month: string = (new Date().getMonth() + 1).toString();
        let year: string = new Date().getFullYear().toString();
        if (month.length < 10) month = "0" + month;
        let currtent_date: string = year + "-" + month + "-" + day;
        return currtent_date;
    }
}