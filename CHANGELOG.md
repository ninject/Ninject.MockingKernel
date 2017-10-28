# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [3.3.0] - 2017-10-28

### Added
- Support auto mocking named interfaces [#17](https://github.com/ninject/Ninject.MockingKernel/issues/17) 

## [3.3.0-beta1]

### Added
 - Support .NET Standard 2.0

### Removed
 - .NET 3.5, .NET 4.0 and Silverlight
 - Dropped Ninject.MockingKernel.RhinoMocks

## [3.2.2]

### Added
- Support FakeItEasy

## [3.2.1]

### Added
- Support additional interfaces when mock

## [3.0.0.0]

### Removed
- No web builds. All builds are have not reference to web anymore

### Added
- (Moq): Support for for strict mocks
- (Moq): The MockRepository can be accessed using kernel.MockRepository