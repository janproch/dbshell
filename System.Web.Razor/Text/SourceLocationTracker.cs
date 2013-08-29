
namespace System.Web.Razor.Text {
    public class SourceLocationTracker {
        private int _absoluteIndex = 0;
        private int _characterIndex = 0;
        private int _lineIndex = 0;
        private SourceLocation _currentLocation;

        public SourceLocation CurrentLocation {
            get { return _currentLocation; }
            set {
                if (_currentLocation != value) {
                    _currentLocation = value;
                    UpdateInternalState();
                }
            }
        }

        public SourceLocationTracker() : this(SourceLocation.Zero) { }
        public SourceLocationTracker(SourceLocation loc) {
            CurrentLocation = loc;

            UpdateInternalState();
        }

        public void UpdateLocation(char characterRead, Func<char> nextCharacter) {
            if (nextCharacter == null) { throw new ArgumentNullException("nextCharacter"); }

            _absoluteIndex++;

            if (characterRead == '\n' || (characterRead == '\r' && nextCharacter() != '\n')) {
                _lineIndex++;
                _characterIndex = 0;
            }
            else {
                _characterIndex++;
            }

            UpdateLocation();
        }

        public void UpdateLocation(string content) {
            for (int i = 0; i < content.Length; i++) {
                Func<char> nextCharacter = () => '\0';
                if (i < content.Length - 1) {
                    nextCharacter = () => content[i + 1];
                }
                UpdateLocation(content[i], nextCharacter);
            }
        }

        private void UpdateInternalState() {
            _absoluteIndex = CurrentLocation.AbsoluteIndex;
            _characterIndex = CurrentLocation.CharacterIndex;
            _lineIndex = CurrentLocation.LineIndex;
        }

        private void UpdateLocation() {
            CurrentLocation = new SourceLocation(_absoluteIndex, _lineIndex, _characterIndex);
        }
    }
}
