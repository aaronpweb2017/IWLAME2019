export interface VSolicitud {
    id_usuario_solicitud: number;
    nombre_usuario: string;
    nombre_solicitud: string;
    status_solicitud: number;
    emision_solicitud: Date;
    aprobacion_solicitud: Date;
}