export function checkForUnsavedChanges(isDirty) {
    if (isDirty) {
        return window.confirm('You have unsaved changes. Are you sure you want to leave?')
    }
    return true;
}