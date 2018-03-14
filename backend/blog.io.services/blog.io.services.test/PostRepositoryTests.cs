using AutoFixture;
using blog.io.common;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace blog.io.services.test
{
    public class PostRepositoryTests
    {
        [Theory]
        [InlineData(30, 2, 10)]
        [InlineData(80, 3, 20)]
        [InlineData(100, 5, 15)]
        public async Task Should_results_be_paged(int total, int page, int qtd)
        {
            var fixture = new Fixture();
            var posts_result =
                Enumerable.Range(0, total)
                .Select(e => fixture.Create<Post>())
                .ToList();

            var rssReader = A.Fake<IRssPostReader>();
            A.CallTo(() => rssReader.ReadPostsAsync(A<string>._, A<DateTime>._)).Returns(posts_result);

            var repository = new PostsRepository(rssReader, DateTime.MinValue, fixture.Create<string>());
            var posts = await repository.GetPagedPosts(page, qtd, null);

            posts.Should().HaveCount(qtd);
            posts_result.IndexOf(posts.First()).Should().Be((page - 1) * qtd);


        }

        [Fact]
        public async Task Should_results_be_filtered_by_userName()
        {
            var fixture = new Fixture();

            Post Create(string authorName)
            {
                var post = fixture.Build<Post>().Without(e => e.Author).Create();
                post.Author = authorName;
                return post;
            };

            var posts_result = new[] {
                Create("Lucas"),
                Create("Bob"),
                Create("Lucas"),
                Create("Jonas"),
                Create("lucas"),
                Create("Michal"),
                Create("Lucas "),
                Create("Ruan"),
                Create("Mudi"),
                Create("LUCAS")
            };


            var rssReader = A.Fake<IRssPostReader>();
            A.CallTo(() => rssReader.ReadPostsAsync(A<string>._, A<DateTime>._)).Returns(posts_result);

            var repository = new PostsRepository(rssReader, DateTime.MinValue, fixture.Create<string>());
            var posts = await repository.GetPagedPosts(1, 10, "Lucas");

            posts.Should().HaveCount(5);
            posts.Should().OnlyContain(e => e.Author.ToLowerInvariant().Contains("lucas"));

        }

        [Fact]
        public async Task Should_return_none_with_invalid_id()
        {
            var fixture = new Fixture();

            var index = 1;
            Post Create(int id)
            {
                var post = fixture.Build<Post>().Without(e => e.Id).Create();
                post.Id = index++;
                return post;
            };

            var posts_result = Enumerable.Range(0, 3).Select(Create).ToArray();

            var rssReader = A.Fake<IRssPostReader>();
            A.CallTo(() => rssReader.ReadPostsAsync(A<string>._, A<DateTime>._)).Returns(posts_result);

            var repository = new PostsRepository(rssReader, DateTime.MinValue, fixture.Create<string>());

            var somePost = await repository.GetPost(999);

            somePost.IsNone.Should().BeTrue();

        }

        [Fact]
        public async Task Should_return_none_with_invalid_path()
        {
            var fixture = new Fixture();

            Post Create(string path)
            {
                var post = fixture.Build<Post>().Without(e => e.Path).Create();
                post.Path = path;
                return post;
            };

            var posts_result = new[] {
                Create("p1"),
                Create("p2"),
                Create("p3"),
            };

            var rssReader = A.Fake<IRssPostReader>();
            A.CallTo(() => rssReader.ReadPostsAsync(A<string>._, A<DateTime>._)).Returns(posts_result);


            var repository = new PostsRepository(rssReader, DateTime.MinValue, fixture.Create<string>());

            var somePost = await repository.GetPost("p4");

            somePost.IsNone.Should().BeTrue();

        }

        [Fact]
        public async Task Should_return_some_with_valid_id()
        {
            var fixture = new Fixture();

            var index = 1;
            Post Create(int id)
            {
                var post = fixture.Build<Post>().Without(e => e.Id).Create();
                post.Id = index++;
                return post;
            };

            var posts_result = Enumerable.Range(0, 3).Select(Create).ToArray();

            var rssReader = A.Fake<IRssPostReader>();
            A.CallTo(() => rssReader.ReadPostsAsync(A<string>._, A<DateTime>._)).Returns(posts_result);


            var repository = new PostsRepository(rssReader, DateTime.MinValue, fixture.Create<string>());

            var somePost = await repository.GetPost(2);

            somePost.IsSome.Should().BeTrue();

            somePost.Some(e => e.Should().BeSameAs(posts_result[1]));

        }

        [Fact]
        public async Task Should_return_some_with_valid_path()
        {
            var fixture = new Fixture();

            Post Create(string path)
            {
                var post = fixture.Build<Post>().Without(e => e.Path).Create();
                post.Path = path;
                return post;
            };

            var posts_result = new[] {
                Create("p1"),
                Create("p2"),
                Create("p3"),
            };

            var rssReader = A.Fake<IRssPostReader>();
            A.CallTo(() => rssReader.ReadPostsAsync(A<string>._, A<DateTime>._)).Returns(posts_result);


            var repository = new PostsRepository(rssReader, DateTime.MinValue, fixture.Create<string>());

            var somePost = await repository.GetPost("p2");

            somePost.IsSome.Should().BeTrue();

            somePost.Some(e => e.Should().BeSameAs(posts_result[1]));

        }
    }



}
