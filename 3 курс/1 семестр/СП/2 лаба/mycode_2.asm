.model tiny

.data
    K dw 10, -10, 20, -20, 30, -30, 40, -40
    sum dw 0
.code

N:
    push cs
    push ds
    
;;;;;;;;;;;;;;;;;;;;;;;;
    mov bx, 0
    mov cx, 8
    
    m:
        mov ax, K[bx]
        cmp ax, 0
        jle m2
        add sum, ax
        
    m2:
        add bx, 2
        loop m

;;;;;;;;;;;;;;;;;;;;;;;;
    mov ax, 4c00h
    int 21h
end N    mov ax, 4c00h
    int 21h
end N