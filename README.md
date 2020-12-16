# GrammAR

## Vision

The user writes something on a piece of paper and wants to validate, if he misspelled something. To do this he can use the AR Application by positioning the camera above the text. The application applies OCR and extracts the written text and positional information (if this is not possible with a given OCR Library, marker based tracking is used to locate the text  and position the hints).
Afterward a simple spell check is performed by looking up several selected word libraries (english, german, spanish, italien).
Then based on the spell check results, the written text is annotated with corrections/hints.

## Feature Roadmap

- [ ] Loading Spinner while loading the results
- [ ] Audio cues for results loading/no errors/errors detected
- [ ] Error message if text could not be detected
- [ ] Spell check and and annotate misspelled words
- [ ] Detect text changes and only refresh results if different sheet is shown
- [ ] Virtual Button for language selection (with a marker)

### Optional Features

- [ ] Curseword bleep 
- [ ] Enhanced Error Message (based on threshold e.g. if 50% could not be detected an error is shown, otherwise words will be ignored)
