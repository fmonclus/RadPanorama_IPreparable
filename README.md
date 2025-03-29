# Solución definitiva para RadPanorama + UserControls en WinForms

## ❗ Problema

Cuando se usan `UserControls` dentro de `RadPanorama` en aplicaciones WinForms (especialmente con Telerik), el evento `VisibleChanged` puede ejecutarse múltiples veces innecesariamente al cargar el formulario, redibujar o reordenar los controles. Esto produce múltiples llamadas a la base de datos o carga de grillas antes de que el control esté realmente visible.

## ✅ Solución

Implementar una interfaz `IPreparable` en cada UserControl que necesite lógica de carga, y llamar al método `PrepararControl()` explícitamente desde el formulario principal (`frmPrincipal`) **solo cuando el control se muestra al usuario**.

## 💡 Beneficios

- Cero dependencias de `VisibleChanged`
- Carga controlada y eficiente
- Código limpio y mantenible
- Ideal para estructuras dinámicas con múltiples `UserControls`

## 📁 Estructura

- `Interfaces/IPreparable.cs` → la interfaz común
- `Pages/usrCategorias.cs` → ejemplo de UserControl que implementa la interfaz
- `frmPrincipal.cs` → donde se maneja la carga y visualización del control

## ✨ Uso

```csharp
if (controlActual is IPreparable preparable)
{
    preparable.PrepararControl();
}
```

¡Listo! Con eso evitás todos los problemas de ejecución múltiple y tenés el control total.
