export interface VSolicitud {
    id: number;
    usuario: string;
    tipo: string;
    status: string;
    emision: Date;
    aprobacion: Date;
}