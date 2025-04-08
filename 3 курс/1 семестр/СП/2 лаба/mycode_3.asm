.model tiny

.data
    a db 120
    b db 20
    c db 5
.code

N:
    push cs
    push ds
    
;;;;;;;;;;;;;;;;;;;;;;;;
    mov al, a
    mov bl, b
    mov cl, c
    
    cmp al, bl
    jle check_c  
    
    mov al, bl
    
    check_c:
        cmp al, cl
        jle ready
        
        mov al, cl
    
    ready:
        mov c, al
;;;;;;;;;;;;;;;;;;;;;;;;

    mov ax, 4c00h
    int 21h
end N