import { Component } from '@angular/core';

@Component({
    selector: 'events-list',
    template: `
    <div class="row">
        <div class="col-md-3" *ngFor="let employee of employees">
            <event-thumbnail [employee]="employee" [employeesQuantity]="employees.length"></event-thumbnail>
        </div>
    </div>
    `
    // templateUrl: './events-list.component.html'
})

export class EventsListComponent {
    employees = [{
            id: 1,
            name: 'Aarón',
            date: '27/02/2019',
            time: '8:00am',
            salary: '5890.00',
            location: {
                address: '1057 CH',
                country: {
                    name:'Mexico',
                    state: 'Sinaloa',
                    city: {
                        name: 'Culiacán',
                        neighborhood: 'Hidalgo'
                    }
                } 
            }
        },
        {
            id: 2,
            name: 'Ramon',
            date: '01/03/2019',
            time: '9:00 am',
            price: '5930.00',
            location: {
                address: '1054 CU',
                country: {
                    name:'Mexico',
                    state: 'Sinaloa',
                    city: {
                        name: 'Culiacán',
                        neighborhood: 'Zaragoza'
                    }
                } 
            }
        },
        {
            id: 3,
            name: 'Carolina',
            date: '28/02/2019',
            time: '10:00 am',
            price: '2731.00',
            location: {
                address: '1055 BM',
                country: {
                    name:'Mexico',
                    state: 'Sinaloa',
                    city: {
                        name: 'Culiacán',
                        neighborhood: 'Unknown Zone'
                    }
                } 
            }
        },
        {
            id: 4,
            name: 'Ruben',
            date: '04/03/2019',
            time: '11:00 am',
            price: '10000.00',
            location: {
                address: '',
                country: {
                    name:'Mexico',
                    state: 'Sinaloa',
                    city: {
                        name: 'Culiacán',
                        neighborhood: 'Unknown Zone'
                    }
                } 
            }
        }
    ]
    handleEventClicked(id) {
        alert('Clicked Employee Number: '+id);
        console.log('Clicked Employee Number: '+id);
    }
}