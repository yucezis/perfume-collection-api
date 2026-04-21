using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Perfume.Services;
using Perfume.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;
using Perfume.DTOs.Gemini;

namespace Perfume.Tests.Controllers
{

    public class GeminiControllerTests
    {

        private readonly Mock<IGeminiService> _geminiServiceMock;
        private readonly GeminiController _sut;

        public GeminiControllerTests()
        {
            _geminiServiceMock = new Mock<IGeminiService>();

            _sut = new GeminiController(_geminiServiceMock.Object);
        }

        [Fact]
        public async Task Ask_WhenPromptIsEmpty_ReturnsBadRequest()
        {
            var emptyRequest = new AskRequestDto("");

            var result = await _sut.Ask(emptyRequest);
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task Ask_ValidPrompt_ReturnsOkWithAnswer()
        {
            var validRequest = new AskRequestDto("Odunsu parfüm öner");
            var excpectedAiResponse = "Size Tom Ford Oud Wood önerebilirim";

            _geminiServiceMock.Setup(x=>x.AskAsync(It.IsAny<string>()))
                .ReturnsAsync(excpectedAiResponse);

            var result = await _sut.Ask(validRequest);

            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeEquivalentTo(new { answer = excpectedAiResponse });
        }

    }
}
